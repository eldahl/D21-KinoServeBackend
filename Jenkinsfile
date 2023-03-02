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

	def remote = [:]
	remote.name = VPS
	remote.host = "51.75.69.121"
	remote.allowAnyHosts = true

	withCredentials([sshUserPrivateKey(credentialsId: '080224dd-befc-44bd-a621-e037477e0a0a', keyFileVariable: 'ident', passphraseVariable: 'pass', usernameVariable: 'user')]) {
	    remote.user = user
            remote.identityFile = ident
	    remote.password = pass

            stage('Deploy') {
		steps {
                    echo 'Deploying....'
		    sh 'dotnet publish KinoServerBackend/KinoServerBackend.csproj -c Release -r linux-x64 --self-contained'
		    echo user
		}
	    }
        }
    }
}
