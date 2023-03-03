pipeline {
    agent any

    stages {
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
				
				node {
					withCredentials([sshUserPrivateKey(credentialsId: '080224dd-befc-44bd-a621-e037477e0a0a', keyFileVariable: 'IDENT', passphraseVariable: 'PASS', usernameVariable: 'USER')]) {
					
						def remote = [:]
						remote.name = 'VPS'
						remote.host = "51.75.69.121"
						remote.allowAnyHosts = true
						remote.user = USER
						remote.indentityFile = IDENT
						remote.password = PASS

						steps {   
							echo 'Deploying ...'
							sh 'dotnet publish KinoServerBackend/KinoServerBackend.csproj -c Release -r linux-x64 --self-contained'
							echo user
						}
					}
				}
			}
		}
    }
}
