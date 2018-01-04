angular.module('reclamosApp.services', [])
.factory('reclamosFactory', function ($q, $http, $location) {
    var webUrl = _spPageContextInfo.webAbsoluteUrl + "/_api/"; 
    var webUrlConfiguracion = _spPageContextInfo.webAbsoluteUrl + "/configuracion/_api/";
    var factory = {};
    factory.createRequest = function(data) {
        var deferred = $q.defer();
        var createRequestURL = webUrl + "lists/GetByTitle('Control%20de%20OOSS-Reclamos%20(CH/SC)')/Items"; 
        $http({
            url: createRequestURL,
            method: "POST",
            headers: {
                "accept": "application/json;odata=verbose",
                "X-RequestDigest": document.getElementById("__REQUESTDIGEST").value,
                "content-Type": "application/json;odata=verbose"
            },
            data: JSON.stringify(data)
        })
        .then(function (result) {
            deferred.resolve(result);
        })
        .catch(function (result, status) {
            deferred.reject(status);
            alert("Status Code: " + status);
        });
        return deferred.promise;
    };
   factory.editRequest = function(data) {
        var deferred = $q.defer();
        var editRequestURL = webUrl + "lists/getbytitle('Control%20de%20OOSS-Reclamos%20(CH/SC)')/items("+ data.ID +")"; 
          $http({
            url: editRequestURL,
            method: "POST",
            headers: 
            {
                "accept": "application/json;odata=verbose",
		        "X-RequestDigest": document.getElementById("__REQUESTDIGEST").value,
		        "If-Match": "*",
		        "content-Type": "application/json;odata=verbose",
		        "X-Http-Method": "MERGE",		      	
		    },
            data: JSON.stringify(data)
        })
        .then(function (result) {
        	console.log(result);
            deferred.resolve(result);
        })
        .catch(function (data, status) {
            deferred.reject(status);
            alert("Status Code: " + status);
        });
        return deferred.promise;
    };
    
   factory.getItemById = function()
    {    	
    	var id = $location.search().ID;
    	var deferred = $q.defer();
        $http({
          
            url: webUrl +"/lists/getbytitle('Control%20de%20OOSS-Reclamos%20(CH/SC)')/items(" + id + ")",   
	  		method: "GET",
            headers: {
                "accept": "application/json;odata=verbose"
            }
        })
        .then( function (data) {
            var result = data.data.d;
        	deferred.resolve(result);
            
        })
        .catch( function (error) {
            deferred.reject(error);
        });
        return deferred.promise;
        
    };
    
    factory.getCliente = function()
    {    	
    	var deferred = $q.defer();
        $http({
     	
            url: webUrlConfiguracion +"/lists/GetByTitle('Clientes')/items?$select=Title",
	   
	  		method: "GET",
            headers: {
                "accept": "application/json;odata=verbose"
            }
        })
        .then( function (data) {
        	var result = data.data.d.results;
        	var i = result.length;
        	deferred.resolve(result);
            
        })
        .catch( function (error) {
            deferred.reject(error);
        });
        return deferred.promise;
        
    };
    
    factory.getCountry = function()
    {
    	
    	var deferred = $q.defer();
        $http({
          
            url: webUrlConfiguracion +"/lists/GetByTitle('Pais')/items?$select=Title",
            method: "GET",
            headers: {
                "accept": "application/json;odata=verbose"
            }
        })
        .then( function (data) {
            var result = data.data.d.results;
        	var i = result.length;
        	deferred.resolve(result);	
            
        })
        .catch( function (error) {
            deferred.reject(error);
        });
        return deferred.promise;
        
    };
    
    factory.getDistrito = function()
    {
    	
    	var deferred = $q.defer();
        $http({        		   
	  		url: webUrlConfiguracion +"/lists/GetByTitle('Distrito')/items?$select=Title",
	  		method: "GET",
            headers: {
                "accept": "application/json;odata=verbose"
            }
        })
        .then( function (data) {
            var result = data.data.d.results;
        	var i = result.length;
        	deferred.resolve(result);	
            
        })
        .catch( function (error) {
            deferred.reject(error);
        });
        return deferred.promise;
        
    };
	
    factory.getTema = function()
    {    	
    	var deferred = $q.defer();
        $http({
          
            url: webUrl +"/lists/GetByTitle('Control%20de%20OOSS-Reclamos%20(CH/SC)')/Fields?$filter=EntityPropertyName%20eq%20%27campo1%27",      	  
	  		method: "GET",
            headers: {
                "accept": "application/json;odata=verbose"
            }
        })
        .then( function (data) {
            var result = data.data.d.results[0].Choices.results;
        	var i = result.length;
        	deferred.resolve(result);	
            
        })
        .catch( function (error) {
            deferred.reject(error);
        });
        return deferred.promise;
        
    };
     factory.getTipoServicio = function()
    {    	
    	var deferred = $q.defer();
        $http({
          
            url: webUrl +"/lists/GetByTitle('Control%20de%20OOSS-Reclamos%20(CH/SC)')/Fields?$filter=EntityPropertyName%20eq%20%27Tipo_x0020_de_x0020_Servicio%27",      	
	  		method: "GET",
            headers: {
                "accept": "application/json;odata=verbose"
            }
        })
        .then( function (data) {
            var result = data.data.d.results[0].Choices.results;
        	var i = result.length;
        	deferred.resolve(result);	
            
        })
        .catch( function (error) {
            deferred.reject(error);
        });
        return deferred.promise;
        
    };
     factory.getCompania = function()
    {    	
    	var deferred = $q.defer();
        $http({
              	
            url: webUrlConfiguracion +"/lists/GetByTitle('Compania')/items?$select=Title",   
	  		method: "GET",
            headers: {
                "accept": "application/json;odata=verbose"
            }
        })
        .then( function (data) {
        	var result = data.data.d.results;
        	var i = result.length;
        	deferred.resolve(result);	
            
        })
        .catch( function (error) {
            deferred.reject(error);
        });
        return deferred.promise;
        
    };
    factory.getEquipo= function()
    {    	
    	var deferred = $q.defer();
        $http({
          
            url: webUrl +"/lists/GetByTitle('Control%20de%20OOSS-Reclamos%20(CH/SC)')/Fields?$filter=EntityPropertyName%20eq%20%27Equipo%27",      	 
	  		method: "GET",
            headers: {
                "accept": "application/json;odata=verbose"
            }
        })
        .then( function (data) {
            var result = data.data.d.results[0].Choices.results;
        	var i = result.length;
        	deferred.resolve(result);	
            
        })
        .catch( function (error) {
            deferred.reject(error);
        });
        return deferred.promise;
        
    };
    factory.getEstado= function()
    {    	
    	var deferred = $q.defer();
        $http({
          
            url: webUrl +"/lists/GetByTitle('Control%20de%20OOSS-Reclamos%20(CH/SC)')/Fields?$filter=EntityPropertyName%20eq%20%27Estado_x0020_de_x0020_la_x0020_O%27",      	
            method: "GET",
            headers: {
                "accept": "application/json;odata=verbose"
            }
        })
        .then( function (data) {
            var result = data.data.d.results[0].Choices.results;
        	var i = result.length;
        	deferred.resolve(result);	
            
        })
        .catch( function (error) {
            deferred.reject(error);
        });
        return deferred.promise;
        
    };
        
    factory.searchPeople = function(request) {    	
	        var deferred = $q.defer();  
	        $http({
	            url: webUrl + "SP.UI.ApplicationPages.ClientPeoplePickerWebServiceInterface.clientPeoplePickerSearchUser",
	            method: "POST",
	            data: JSON.stringify({'queryParams':{
	                    '__metadata':{
	                        'type':'SP.UI.ApplicationPages.ClientPeoplePickerQueryParameters'
	                    },
	                    'AllowEmailAddresses':true,
	                    'AllowMultipleEntities':false,
	                    'AllUrlZones':false,
	                    'MaximumEntitySuggestions':50,
	                    'PrincipalSource':15,
	                    'PrincipalType': 1,
	                    'QueryString':request
	                }
	            }),
	            headers: {
	                "accept": "application/json;odata=verbose",
	                'content-type':'application/json;odata=verbose',
	               'X-RequestDigest': document.getElementById('__REQUESTDIGEST').value
	            }
	        })
	        .then(function (result) {
	            var data = JSON.parse(result.data.d.ClientPeoplePickerSearchUser);
	            var formattedPeople = [];
	            var topResultsGroup = { name: "Top Results", order: 0 };
	            if (data.length > 0) {
	                angular.forEach(data, function (value, key) {
	                    var name = value.DisplayText;
	                    var userInitials = name.match(/\b\w/g) || [];
	                    userInitials = ((userInitials.shift() || '') + (userInitials.pop() || '')).toUpperCase();	  
	                    formattedPeople.push({
	                        initials: userInitials,
	                         primaryText: name,
	                         secondaryText: value.EntityData.Department,        
	                         presence: 'available',
	                         group: topResultsGroup,    
	                         color: 'blue',
	                         id: value.Key
	                     });    
	                });
	                deferred.resolve(formattedPeople);
	            }
	        })
	        .catch(function (result, status) {
	            deferred.reject(status);
	            alert("Status Code: " + status);
	        });
	        return deferred.promise;
	    };
	     	    	
	    factory.getUserId = function (UserName) { 
	        var deferred = $q.defer();
	        $http({
	            url: webUrl + "web/siteusers(@v)?@v='" + encodeURIComponent(UserName) + "'",
	            method: "GET",
	            headers: {
	                "accept": "application/json;odata=verbose"
	            }
	        })
	        .then(function (result) {
	            deferred.resolve(result);
	        })
	        .catch(function (result, status) {
	            deferred.reject(status);
	        });
	        return deferred.promise;
	        

    };
	




    
    
    
    
    
    

    return factory;
});  