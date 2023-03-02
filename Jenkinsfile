pipeline {
    agent any

    def remote = [:]
    remote.name = VPS
    remote.host = "51.75.69.121"
    remote.allowAnyHosts = true

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
                withCredentials([sshUserPrivateKey(credentialsId: '080224dd-befc-44bd-a621-e037477e0a0a', keyFileVariable: 'ident', passphraseVariable: 'pass', usernameVariable: 'user')]) {
		    remote.user = user
		    remote.indentityFile = ident
		    remote.password = pass

		    echo 'Deploying ...'
		    sh 'dotnet publish KinoServerBackend/KinoServerBackend.csproj -c Release -r linux-x64 --self-contained'
                    echo user
		}
	    }
	}

    }
}
