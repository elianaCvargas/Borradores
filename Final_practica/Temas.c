#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "Arraylist.h"
#include "Temas.h"
#include "Parser.h"


Temas* Temas_new(void)
{
    Temas* returnAux = NULL;
    returnAux = (Temas*)malloc(sizeof(Temas));
    return returnAux;
}



int Temas_setId(Temas* this, int id)
{
    int retorno = -1;

    if(this != NULL && id > 0)
    {
        this->id= id;
        retorno = 0;
    }
    return retorno;
}

int Temas_setName(Temas* this,char* name)
{
    int retorno = -1;

    if(this != NULL && strlen(name) > 0)
    {
        strcpy(this->name,name);
        retorno = 0;
    }
    return retorno;
}


int Temas_setArtista(Temas* this,char* artista)
{
    int retorno = -1;

    if(this != NULL && strlen(artista) > 0)
    {
        strcpy(this->artista,artista);
        retorno = 0;
    }
    return retorno;
}


int Temas_getId(Temas* this)
{
    int retorno = -1;
    if(this!= NULL)
        retorno = this->id;
    return retorno;
}

void* Temas_getName(Temas* this)
{
    char* retorno = NULL;
    if(this != NULL)
        retorno =  this->name;
    return retorno;
}

void* Temas_getArtista(Temas* this)
{
    char* retorno = NULL;
    if(this != NULL)
        retorno =  this->artista;
    return retorno;
}

void Temas_printAll(ArrayList* this)
{
    Temas* Temas;
    int lenLista = this->len(this);
    int i;
    for(i  = 0; i <lenLista ; i++)
    {
        Temas = this->get(this, i);
       printf("ID:%d Name:%-10s Artista:%-10s\n",Temas->id ,Temas->name, Temas->artista);
    }

}


int Temas_compareName(void* usuarioA,void* usuarioB)
{
    Temas* personaA = (Temas*)usuarioA;
    Temas* personaB = (Temas*)usuarioB;
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

int Temas_compareArtista(void* usuarioA,void* usuarioB)
{
    Temas* personaA = (Temas*)usuarioA;
    Temas* personaB = (Temas*)usuarioB;
    if(strcmp(personaA->artista, personaB->artista)>0)
    {
        return 1;
    }
    if(strcmp(personaA->artista, personaB->artista)<0)
    {
        return -1;
    }
    return 0;
}

void Temas_ordenar(ArrayList* this)
{
    /*int i, j;
    int len = this->len(this);
    Temas* temaA = NULL;
    Temas* temaB = NULL;
    Temas* aux = NULL;*/



    int i,j;
    int lenLista = this->len(this);
    Temas* auxiliar = NULL;
    Temas* auxTemasA= NULL;
    Temas* auxTemasB = NULL;
    al_sort(this,Temas_compareName, 1);
    for(i = 0; i < lenLista-1; i++)
    {
        for(j = i+1; j < lenLista; j++)
        {
            auxTemasA = (Temas*)this->get(this, i);
            auxTemasB = (Temas*)this->get(this,j);
            if(Temas_compareName(auxTemasA, auxTemasB)==0 && Temas_compareArtista(auxTemasA, auxTemasB)>0)
            {

                //this->set(this,i,auxTemasA);
                //this->set(this,j,auxTemasB);
                auxiliar = auxTemasA;
                auxTemasA = auxTemasB;
                auxTemasB = auxiliar;

            }
        }
    }


    /*for(i = 0; i <len-1; i ++)
    {
        for(j = i+1; j < len ; j++)
        {
            temaA = (Temas*)this->get(this, i);
            temaB = (Temas*)this->get(this, j);
            if(strcmp(temaA->artista, temaB->artista)>0)
            {
                aux = temaA;
                temaA =  temaB;
                temaB = aux;
            }
            if(strcmp(temaA->artista, temaB->artista)==0 )
    {
        if(strcmp(temaA->name, temaB->name)>0)
        {
            aux = temaA;
            temaA =  temaB;
            temaB = aux;
        }

    }

        }

    }*/



}









