node {
    def app
    stage('Clean workspace')
        cleanWs()

	stage('Checkout'){
		checkout scm
    }
	
    stage('Build') {       
        app = docker.build("immersed/immersed.flight.plans:${env.BUILD_ID}")    
    }

    stage('Integration Testing') {
    }

    stage('Publish') {       
        docker.withRegistry('https://registry.hub.docker.com', 'immersedDockerRepo'){
            app.push("${env.BUILD_NUMBER}")            
            app.push("latest")  
        }        
    }    

	stage('Archive'){
        archive 'ProjectName/bin/Release/**'
    }
}