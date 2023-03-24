pipeline {
    agent any

    stages {
        stage('Start up') {
			steps {
				dir('KSBTests') {
					sh 'rm -rf TestResults'
				}
			}
		}
		
		stage('Build') {
            steps {
                echo 'Building..'
				sh 'dotnet build'
            }
        }
		
		stage('Test') {
            steps {
                echo 'Testing..'
				sh 'dotnet test'
				
				dir('KSBTests') {
					sh 'dotnet add package coverlet.collector'
					sh 'dotnet add package coverlet.msbuild'
					sh "dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:ExcludeByFile='**/*Migrations/*.cs'"
				}
            }			
			post {
				success {
					archiveArtifacts 'KSBTests/coverage.cobertura.xml'
					publishCoverage adapters: [istanbulCoberturaAdapter(path: 'KSBTests/coverage.cobertura.xml', thresholds: [
						[failUnhealthy: true, thresholdTarget: 'Conditional', unhealthyThreshold: 80.0, unstableThreshold: 50.0]
					])], checksName: '', sourceFileResolver: sourceFiles('NEVER_STORE')
				}
			}
        }
		
		stage('Deploy') {
			steps {   
				echo 'Deploying ...'
				sh 'rm -rf KinoServerBackend/appsettings.*'
				sh 'cp ~/cred/* KinoServerBackend'
				sh 'docker build . -t ksbackend'
				
				// Standalone image
				//sh 'docker run -d -p 80:80 ksbackend'
				
				// With database
				sh 'docker compose up -d'
				
				// Apply migrations
				dir('KinoServerBackend') {
					sh 'dotnet tool list -g'
					sh 'dotnet-ef database update'
				}
			}
		}
    }
}

