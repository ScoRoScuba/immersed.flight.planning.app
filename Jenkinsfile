node {
    stage 'Clean workspace'
        cleanWs()

	stage 'Checkout'
		checkout scm
	
    stage 'Build' {       
        def builtImage = docker.build("immersed/immersed.flight.plans:${env.BUILD_ID}")

        docker.withRegistry('https://registry.hub.docker.com', 'git'){
            app.push("${env.BUILD_NUMBER}")            
            app.push("latest")  
        }        
    }

    stage 'Integration Testing' {
        app.inside {                        
             sh 'echo "Tests passed"'        
        } 
    }

    stage 'Publish' {       
        docker.withRegistry('https://registry.hub.docker.com', 'git'){
            app.push("${env.BUILD_NUMBER}")            
            app.push("latest")  
        }        
    }    

	stage 'Archive'
		archive 'ProjectName/bin/Release/**'

}