#include <stdio.h>
#include <stdlib.h>
#include "ArrayList.h"
#include "Usuario.h"
#include "Temas.h"

//“id,nombre,email,sexo,pais,password,ip_address”.
int parserUsuarios(FILE* pFile , ArrayList* lista)
{
    char id[50];
    char nombre[50];
    char email[50];
    char sexo[50];
    char pais[50];
    char password[50];
    char ip_adress[50];

    Usuario* auxUsuario;
    pFile = fopen ("usuarios.dat", "r");
    if(pFile==NULL)
        exit(0);
    while(!feof(pFile))
    {
        fscanf(pFile, "%[^,],%[^,],%[^,],%[^,],%[^,],%[^,],%[^\n]\n", id,nombre, email, sexo, pais, password, ip_adress);
        auxUsuario = Usuario_new();
        Usuario_setId(auxUsuario,atoi(id));
        Usuario_setName(auxUsuario, nombre);
        Usuario_setEmail(auxUsuario, email);
        Usuario_setSexo(auxUsuario, sexo);
        Usuario_setPais(auxUsuario,pais);
        Usuario_setPassword(auxUsuario, password);
        Usuario_setIP_adress(auxUsuario, ip_adress);

        lista->add(lista, auxUsuario);
    }
    fclose(pFile);
    return 0;
}

int parserTemas(FILE* pFile , ArrayList* lista)
{
    char id[50];
    char nombre_tema[50];
    char artista[50];


    Temas* auxTemas;
    pFile = fopen ("temas.dat", "r");
    if(pFile==NULL)
        exit(0);
    while(!feof(pFile))
    {
        fscanf(pFile, "%[^,],%[^,],%[^\n]\n", id,nombre_tema, artista);
        auxTemas = Temas_new();
        Temas_setId(auxTemas,atoi(id));
        Temas_setName(auxTemas, nombre_tema);
        Temas_setArtista(auxTemas, artista);
        lista->add(lista, auxTemas);
    }
    fclose(pFile);
    return 0;
}


