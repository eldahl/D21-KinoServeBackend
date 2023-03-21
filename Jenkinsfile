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
					sh "dotnet test --collect: 'XPlat Code Coverage' --settings coverlet.runsettings"
				}
            }			
			post {
				success {
					archiveArtifacts 'KSBTests/TestResults/*/coverage.cobertura.xml'
					publishCoverage adapters: [istanbulCoberturaAdapter(path: 'KSBTests/TestResults/*/coverage.cobertura.xml', thresholds: [
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
			}
		}
    }
}

