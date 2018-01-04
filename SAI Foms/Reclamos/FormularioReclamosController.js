angular.module('reclamosApp.controllers', [])
.controller('reclamosController', function ($scope, $q, $timeout,reclamosFactory, $window, $location) 
{
	init();
	function init( ) 
	{	
		reclamosFactory.getCountry().then(function (paises) {
	        $scope.Paises = paises;
	    });
	    reclamosFactory.getDistrito().then(function (distritos) {
	        $scope.Distritos = distritos;
	    });
	        	       
	    reclamosFactory.getCliente().then(function (clientes) {
	        $scope.Clientes = clientes;
	    });	 

	    reclamosFactory.getTema().then(function (temas) {
	        $scope.Temas = temas;
	    });	
	    reclamosFactory.getTipoServicio().then(function (tiposServicios) {
	        $scope.TiposServicios = tiposServicios;
	    });
	    reclamosFactory.getCompania().then(function (companias) {
	        $scope.Companias = companias;
	    });
	    reclamosFactory.getEquipo().then(function (equipos) {
	        $scope.Equipos= equipos;
	    });
	    reclamosFactory.getEstado().then(function (estados) {
	        $scope.Estados= estados;
	    });
	    
	    var id = $location.search().ID;
        if(id == undefined)
        {
	        $scope.reclamosRequest = 
		    {	 
		        Title: '',
		        Pais: 'Argentina',
		        Distrito: '',	            
		        Fecha: '', 
		        Cliente:'',		            	           
		        Numero_x0020_de_x0020_la_x0020_O: '',	            
		        campo1:'',
		        Tipo_x0020_de_x0020_Servicio:'',
		        Compa_x00f1_ia_x003a_: '',
		        Equipo:'',
		        Fecha_x0020_de_x0020_Vencimiento:'',
		        Estado_x0020_de_x0020_la_x0020_O:'',
		        Fecha_x0020_Real_x0020_de_x0020_:'',
		        Responsable_x0020_de_x0020_An_x0Id:null,
		        Responsable_x0020_de_x0020_An_x0:[],
		        CodigoInternoSAI:'',	           
		        __metadata: { 'type': 'SP.Data.Control_x0020_de_x0020_OOSSReclamos_x0020_CHSCListItem' }
		            
		    };        	
        }    
        else
        {
	         reclamosFactory.getItemById().then(function (data) 
	         {
			     $scope.reclamosRequest = 
				 {	 
				     Title: data.Title,
				     Pais:data.Pais,
				     Distrito: data.Distrito,	            
				     Fecha:data.Fecha, 
			         Cliente: data.Cliente,		            	           
			         Numero_x0020_de_x0020_la_x0020_O: data.Numero_x0020_de_x0020_la_x0020_O,	            
			         campo1:data.campo1,
			         Tipo_x0020_de_x0020_Servicio:data.Tipo_x0020_de_x0020_Servicio,
			         Compa_x00f1_ia_x003a_:  data.Compa_x00f1_ia_x003a_,
				     Equipo:data.Equipo,
				     Fecha_x0020_de_x0020_Vencimiento: data.Fecha_x0020_de_x0020_Vencimiento,
				     Estado_x0020_de_x0020_la_x0020_O: data.Estado_x0020_de_x0020_la_x0020_O,
				     Fecha_x0020_Real_x0020_de_x0020_:data.Fecha_x0020_Real_x0020_de_x0020_,
				     Responsable_x0020_de_x0020_An_x0Id: data.Responsable_x0020_de_x0020_An_x0Id,
				     Responsable_x0020_de_x0020_An_x0:data.Responsable_x0020_de_x0020_An_x0,
				     CodigoInternoSAI:data.CodigoInternoSAI,
				     ID: data.ID,	           
				     __metadata: { 'type': 'SP.Data.Control_x0020_de_x0020_OOSSReclamos_x0020_CHSCListItem' }				            
				 };			        
		    });
		} 	        	        
	}
	
	var asyncUsers = [];
    var getPeople = function (people, searchQuery) {
        if (!searchQuery) {
          return [];
        }
        console.log("Searching for " + searchQuery);
        return people;
    }	
   
	$scope.getUserResponsable= function (query) 
	{	
        var deferred = $q.defer();
        if( query !=undefined && query !="")
        {
	        reclamosFactory.searchPeople (query).then(function (results) {
	            asyncUsers = JSON.parse(JSON.stringify(results));
	            $scope.asyncUsersResults = getPeople(asyncUsers , query);
	            if (!$scope.asyncUsersResults || $scope.asyncUsersResults.length === 0) 
	            {
	                return $scope.asyncUsersResults;
	            }
	            deferred.resolve($scope.asyncUsersResults);
	        });
	        return deferred.promise;
	    }    
    }
	

    $scope.getSelectedUserId = function (data) 
    {   
        var userId = data.Responsable_x0020_de_x0020_An_x0[0].id;
        reclamosFactory.getUserId(userId).then(function (results) 
        {
            data.Responsable_x0020_de_x0020_An_x0Id = results.data.d.Id;
            console.log(results.data.d.Id);
            userId = null;
        });
    }
    
    $scope.submitRequest = function (data, valid)
    {   
    	//var vm = this;
	    if(valid)
	    {	    	
	    	delete data.Responsable_x0020_de_x0020_An_x0;
	        if(data.ID == undefined)
	        {
		        reclamosFactory.createRequest(data).then(function (results) 
		        {		        	
		        	$window.location.href = '/Lists/Control%20de%20OOSSReclamos%20CHSC/AllItems.aspx';        
					return results;
		        });	        
	        }
	        else
	        {
		        reclamosFactory.editRequest(data).then(function (results) 
			    {		        	
			        $window.location.href = '/Lists/Control%20de%20OOSSReclamos%20CHSC/AllItems.aspx';        
					return results;
			    });		        	
	        }
	        
	       // vm.validateData = true;
	    }
	    else{
	    	console.log("Invalid form");
	    	//this.valid =  false;
	    	//vm.validateData = false;
	    	//console.log(this.valid);	
	    }    	
    }
    
  
    $scope.cancel = function() 
    {
     	$window.location.href = '/Lists/Control%20de%20OOSSReclamos%20CHSC/AllItems.aspx';
    } 
    
    
   
});