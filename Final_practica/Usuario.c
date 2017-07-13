#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "Arraylist.h"
#include "Usuario.h"
#include "Parser.h"

Usuario* Usuario_new(void)
{
    Usuario* returnAux = NULL;
    returnAux = (Usuario*)malloc(sizeof(Usuario));
    return returnAux;
}



int Usuario_setId(Usuario* this, int id)
{
    int retorno = -1;

    if(this != NULL && id > 0)
    {
        this->id= id;
        retorno = 0;
    }
    return retorno;
}

int Usuario_setName(Usuario* this,char* name)
{
    int retorno = -1;

    if(this != NULL && strlen(name) > 0)
    {
        strcpy(this->name,name);
        retorno = 0;
    }
    return retorno;
}


int Usuario_setEmail(Usuario* this,char* email)
{
    int retorno = -1;

    if(this != NULL && strlen(email) > 0)
    {
        strcpy(this->email,email);
        retorno = 0;
    }
    return retorno;
}

int Usuario_setSexo(Usuario* this,char* sexo)
{
    int retorno = -1;

    if(this != NULL && strlen(sexo) > 0)
    {
        strcpy(this->sexo,sexo);
        retorno = 0;
    }
    return retorno;
}

int Usuario_setPais(Usuario* this,char* pais)
{
    int retorno = -1;

    if(this != NULL && strlen(pais) > 0)
    {
        strcpy(this->pais,pais);
        retorno = 0;
    }
    return retorno;
}

int Usuario_setPassword(Usuario* this,char* password)
{
    int retorno = -1;

    if(this != NULL && strlen(password) > 0)
    {
        strcpy(this->password,password);
        retorno = 0;
    }
    return retorno;
}

int Usuario_setIP_adress(Usuario* this,char* ip)
{
    int retorno = -1;

    if(this != NULL && strlen(ip) > 0)
    {
        strcpy(this->ip_adress,ip);
        retorno = 0;
    }
    return retorno;
}

int Usuario_getId(Usuario* this)
{
    int retorno = -1;
    if(this!= NULL)
        retorno = this->id;
    return retorno;
}

void* Usuario_getName(Usuario* this)
{
    char* retorno = NULL;
    if(this != NULL)
        retorno =  this->name;
    return retorno;
}

void* Usuario_getEmail(Usuario* this)
{
    char* retorno = NULL;
    if(this != NULL)
        retorno =  this->email;
    return retorno;
}

void* Usuario_getSexo(Usuario* this)
{
    char* retorno = NULL;
    if(this != NULL)
        retorno =  this->sexo;
    return retorno;
}

void* Usuario_getPais(Usuario* this)
{
    char* retorno = NULL;
    if(this != NULL)
        retorno =  this->pais;
    return retorno;
}

void* Usuario_getPassword(Usuario* this)
{
    char* retorno = NULL;
    if(this != NULL)
        retorno =  this->password;
    return retorno;
}

void* Usuario_getIP_adress(Usuario* this)
{
    char* retorno = NULL;
    if(this != NULL)
        retorno =  this->ip_adress;
    return retorno;
}

void Usuario_printAll(ArrayList* this)
{
    Usuario* Usuario;
    int lenLista = this->len(this);
    int i;
    for(i  = 0; i <lenLista ; i++)
    {
        Usuario = this->get(this, i);
       printf("ID:%d Name:%-10s Email:%-10s Sexo: %-10sPais: %-10sPassword: %-10sIP Adress:%-10s\n",Usuario->id ,Usuario->name, Usuario->email,  Usuario->sexo, Usuario->pais, Usuario->password, Usuario->ip_adress);
    }

}

int Usuario_compareName(void* usuarioA,void* usuarioB)
{
    Usuario* personaA = (Usuario*)usuarioA;
    Usuario* personaB = (Usuario*)usuarioB;
    if(strcmp(personaA->name, personaB->name)>0)
    {
        return 1;
    }
    if(strcmp(personaA->name, personaB->name)<0)
    {
        return -1;
    }
    return 0;
}

int Usuario_comparePais(void* usuarioA,void* usuarioB)
{
    Usuario* personaA = (Usuario*)usuarioA;
    Usuario* personaB = (Usuario*)usuarioB;
    if(strcmp(personaA->pais, personaB->pais)>0)
    {
        return 1;
    }
    if(strcmp(personaA->pais, personaB->pais)<0)
    {
        return -1;
    }
    return 0;
}

int Usuario_compareEmail(void* usuarioA,void* usuarioB)
{
    Usuario* personaA = (Usuario*)usuarioA;
    Usuario* personaB = (Usuario*)usuarioB;
    if(strcmp(personaA->email, personaB->email)>0)
    {
        return 1;
    }
    if(strcmp(personaA->email, personaB->email)<0)
    {
        return -1;
    }
    return 0;
}

void Usuario_ordenar(ArrayList* this)
{
   al_sort(this, Usuario_compareName,1);




}

void Usuario_ordenarPorNombreyPais(ArrayList* this)
{
    int i,j;
    int lenLista = this->len(this);
    Usuario* auxiliar = NULL;
    Usuario* auxUsuarioA= NULL;
    Usuario* auxUsuarioB = NULL;
    al_sort(this,Usuario_compareName, 1);
    for(i = 0; i < lenLista-1; i++)
    {
        for(j = i+1; j < lenLista; j++)
        {
            auxUsuarioA = (Usuario*)this->get(this, i);
            auxUsuarioB = (Usuario*)this->get(this,j);
            if(Usuario_compareName(auxUsuarioA, auxUsuarioB)==0 && Usuario_comparePais(auxUsuarioA, auxUsuarioB)>0)
            {

                //this->set(this,i,auxUsuarioA);
                //this->set(this,j,auxUsuarioB);
                auxiliar = auxUsuarioA;
                auxUsuarioA = auxUsuarioB;
                auxUsuarioB = auxiliar;

            }
        }
    }

}


int Usuario_buscarEmail(ArrayList* this, char email[])
{
    int i;
    int lenLista= this->len(this);
    Usuario* usuario;
    if(this != NULL)
    {
        for(i = 0 ;  i  <lenLista; i++)
        {
            usuario = (Usuario*)this->get(this, i);
            if(strcmp(usuario->email, email)==0)
            {

                return usuario->id;
            }
        }

    }
    return -1;
}

int Usuario_buscarPassword(ArrayList* this, int id, char pass[])//busco  directamente por id
{
    int i;
    int lenLista= this->len(this);
    Usuario* usuario;
    if(this != NULL)
    {
        for(i = 0 ;  i  <lenLista; i++)
        {
            usuario = (Usuario*)this->get(this, i);
            if((usuario->id == id) && strcmp(usuario->password, pass)==0)
            {
                return 0;
            }
        }

    }
    return -1;
}



/*void Usuario_ordenarPorNombreyPais(ArrayList* this)
{
    int i, flag =1;
    int lenLista = this->len(this);
    Usuario* auxiliar = NULL;
    Usuario* auxUsuarioA= NULL;
    Usuario* auxUsuarioB = NULL;
    while(flag)
    {
        flag = 0;
        for(i = 1; i <lenLista; i++)
        {
            auxUsuarioA = (Usuario*) this->get(this, i);
            auxUsuarioB = (Usuario*)this->get(this, i-1);
            if(strcmp(auxUsuarioA->name, auxUsuarioB->name)< 0)
            {
                auxiliar = auxUsuarioA;
                auxUsuarioA = auxUsuarioB;
                auxUsuarioB = auxiliar;
                flag = 1;
            }
            else{
                if(strcmp(auxUsuarioA->name, auxUsuarioB->name)==0)
                {
                    if(strcmp(auxUsuarioA->email, auxUsuarioB->email)< 0)
                    {
                        auxiliar = auxUsuarioA;
                        auxUsuarioA = auxUsuarioB;
                        auxUsuarioB = auxiliar;
                        flag= 1;
                    }
                }
            }
        }
    }


}*/

/*

int Usuario_buscarEmail(ArrayList* this, char email[])
{
    int i;
    int lenLista= this->len(this);
    Usuario* usuario = NULL;
    if(this != NULL)
    {
        for(i = 0 ;  i  <lenLista; i++)
        {
            usuario = this->get(this, i);
            if(strcmp(usuario->email, email)==0)
            {

                return 0;
            }
        }
        printf("AVISO: Retorna -1, pero  puede que sea porque no  parseaste");
        system("pause");
    }
    return -1;
}


int Usuario_buscarPassword(ArrayList* this, char pass[])
{
    int i;
    int lenLista= this->len(this);
    Usuario* usuario = NULL;
    if(this != NULL)
    {
        for(i = 0 ;  i  <lenLista; i++)
        {
            usuario = this->get(this, i);
            if(strcmp(usuario->password, pass)==0)
            {

                return usuario->id;
            }
        }
        printf("AVISO: Retorna -1, pero  puede que sea porque no  parseaste");
        //system("pause");
    }
    return -1;
}


*/
























