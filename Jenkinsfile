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
					sh "dotnet test --collect: 'XPlat Code Coverage'"
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
				sh 'dotnet publish KinoServerBackend/KinoServerBackend.csproj -c Release -r linux-x64 --self-contained'
				sh 'docker build KinoServerBackend/Dockerfile -t KSBackend
			}
		}
    }
}

