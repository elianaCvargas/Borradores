#include <stdio.h>
#include <stdlib.h>
#include "ArrayList.h"
#include "Persona.h"


int parserPersona(FILE* pFile , ArrayList* lista)
{

    char name[51];
    char email[100];

    int i=0;
    pFile = fopen ("destinatarios.csv", "r");

    if(pFile==NULL)
        exit(0);


    while(!feof(pFile))
    {
        fscanf(pFile, "%[^,],%[^\n]\n", name, email);

        if(i==0)
        {
            i++;
            continue;
        }
        Persona* persona;
        persona = persona_new(name, email);
        lista->add(lista,persona);

    }

    fclose(pFile);
    return 0;
}

int parserListaNegra(FILE* pFile , ArrayList* lista)
{

    char name[51];
    char email[100];

    int i=0;
    pFile = fopen ("black_list.csv", "r");

    if(pFile==NULL)
        exit(0);


    while(!feof(pFile))
    {
        fscanf(pFile, "%[^,],%[^\n]\n", name, email);

        if(i==0)
        {
            i++;
            continue;
        }
        Persona* persona;
        persona = persona_new(name, email);
        lista->add(lista,persona);

    }

    fclose(pFile);
    return 0;
}


