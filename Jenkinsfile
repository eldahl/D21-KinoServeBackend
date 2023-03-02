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
                echo 'Deploying....'
		sh 'dotnet publish -c Release -r linux-x64 --self-contained'
		publishOverFtp (
          		configFile: 'Backend deploy', // The name of your FTP configuration in Jenkins
			failOnError: true, // Whether to fail the build if there are any errors during the upload
			flatten: false, // Whether to flatten the directory structure of the files being uploaded
			includes: '**/*', // The file pattern to include in the upload
			remoteDirectory: '~/API' // The directory on the remote FTP server to upload the files to
        	)
            }
        }
    }
}
