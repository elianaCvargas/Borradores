#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "Arraylist.h"
#include "Persona.h"

static int id = 0;

Persona* persona_new( char name[],char email[])
{
    Persona* returnAux = NULL;
    returnAux=(Persona*)malloc(sizeof(Persona));
    strcpy(returnAux->nombre,name);
    strcpy(returnAux->email,email);
    return returnAux;
}

/*Employee* employee_new(int id, char name[],char lastName[])
{
    Employee* returnAux = NULL;

    returnAux=(Employee*)malloc(sizeof(Employee));
    returnAux->id=id;
    strcpy(returnAux->name,name);
    strcpy(returnAux->lastName,lastName);

    return returnAux;
}*/

int persona_setId(Persona* this, int id)
{
    int retorno = -1;
    if(this != NULL && id > 0)
    {
        this->id = id;
        retorno = 0;
    }
    return retorno;
}

int persona_setNombre(Persona* this,char* name)
{
    int retorno = -1;
    if(this != NULL && strlen(name) > 0)
    {
        strcpy(this->nombre, name);
        retorno = 0;
    }
    return retorno;
}

int persona_setEmail(Persona* this,char* email)
{
    int retorno = -1;
    if(this != NULL && strlen(email) > 0)
    {
        strcpy(this->email, email);
        retorno = 0;
    }
    return retorno;
}


int persona_getSId()
{
    id++;
    return id;
}

int persona_getId(Persona* this)
{
    int retorno = -1;
    if(this!= NULL)
        retorno = this->id;
    return retorno;
}

void* persona_getNombre(Persona* this)
{
    char* retorno = NULL;
    if(this != NULL)
        retorno =  this->nombre;
    return retorno;
}

void* persona_getEmail(Persona* this)
{
    char* retorno = NULL;
    if(this!= NULL)
        retorno =  this->email;
    return retorno;
}


int persona_append (Persona* this, char* name, char* email)
{
    int retorno = -1;

    if(this != NULL)
    {
        persona_setNombre(this, name);
        persona_setEmail(this, email);
        retorno = 0;
    }
    return retorno;
}


/*void persona_print(ArrayList* this)
{
    Persona* persona;
    printf("Name: %-15s Email: %15s\n",
               this->nombre,
               this->email);
}*/

void persona_printAll(ArrayList* this)
{
    Persona* persona;
    int lenLista = this->len(this);
    int i;
    for(i  = 0; i <lenLista ; i++)
    {
        persona = this->get(this, i);
       printf("Name: %-15s Email: %15s\n",persona->nombre, persona->email);
    }

}

/*void persona_printAll(ArrayList* this)
{
    int i=0;
    Persona* persona;
    for (i=0; i<this->len(this); i++)
    {
        printf("%d", i);
        persona= (Persona*)al_get(this, i);
        persona_print(this);
    }
}*/




int persona_compare(void* A, void* B)
{
    int retorno;
    Persona* personaA = (Persona*)A;
    Persona* personaB = (Persona*)B;

    if(stricmp(personaA->email,personaB->email)>0)//no  son iguales
    {

        retorno=1;
    }
     if(stricmp(personaA->email,personaB->email)<0)//no  son  iguales
    {
        retorno=-1;
    }
     if(stricmp(personaA->email,personaB->email)==0)//son  iguales
    {
        retorno=0;
    }
    return retorno;

}


void depurar(ArrayList* listaDestinatarios, ArrayList* ListaNegra, ArrayList* nuevaLista)
{

    int i, j;
    int flagAdd = 0;
    int lenListaDestinatarios =listaDestinatarios->len(listaDestinatarios);
    int lenListaNegra = ListaNegra->len(ListaNegra);

    Persona* AuxA = NULL;
    Persona* AuxB = NULL;
    for(i = 0; i < lenListaDestinatarios; i++)
    {
        for(j = 0; j < lenListaNegra; j++)
        {
            AuxA = listaDestinatarios->get(listaDestinatarios, i);
            AuxB = ListaNegra->get(ListaNegra, j);

            if(persona_compare(AuxA, AuxB)==0)
            {
                flagAdd = 1;

            }
            flagAdd = 0;


        }
        if(flagAdd ==0 )
        {
            al_add(nuevaLista, AuxA );
        }
    }
}




void persona_ordenarPorNombre (ArrayList* this)
{
    //int i,j;
    //int longitud = this->len(this);
    //void* empleadoA, *empleadoB;
    //Persona* auxA =  NULL;
    //Persona* auxB =  NULL;


            printf("entro  al  for 2\n");
            //auxA=this->get(this,i);
            //auxB=this->get(this,j);
            al_sort(this,persona_compare, 1);

    persona_printAll(this);
}
















