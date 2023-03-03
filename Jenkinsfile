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
            }
        }
		
		stage('Deploy') {
			steps {   
				withCredentials([sshUserPrivateKey(credentialsId: '080224dd-befc-44bd-a621-e037477e0a0a', keyFileVariable: 'IDENT', passphraseVariable: 'PASS', usernameVariable: 'USER')]) {
				
					def remote = [:]
					remote.name = 'VPS'
					remote.host = "51.75.69.121"
					remote.allowAnyHosts = true
					remote.user = USER
					remote.indentityFile = IDENT
					remote.password = PASS

					echo 'Deploying ...'
					sh 'dotnet publish KinoServerBackend/KinoServerBackend.csproj -c Release -r linux-x64 --self-contained'
					echo user
				}
			}
		}
    }
}
