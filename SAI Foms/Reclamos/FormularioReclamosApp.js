var app = new angular.module(
	'reclamosApp', [
	'reclamosApp.services',
	'reclamosApp.controllers',
	'officeuifabric.core',
    'officeuifabric.components'
  	])
  	.config(function($locationProvider){
    $locationProvider.html5Mode({
  		enabled: true,
  		requireBase: false
		}); 
  	}
 );
  	
  
  
  
  
  