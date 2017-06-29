#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "arraylist.h"
#include "Persona.h"
#include "parser.h"

int main()
{

     ArrayList* listaDestinatarios = al_newArrayList();
     ArrayList* ListaListaNegra = al_newArrayList();
     ArrayList* listaNueva = al_newArrayList();
    int retorno;
    FILE* pArchivo = NULL;
    //FILE* pArchivo2;


    char seguir='s';
    int opcion=0;

    if(listaDestinatarios != NULL )
    {

        while(seguir=='s')
        {
            printf("1- Cargar destinatario\n");
            printf("2- Cargar Lista Negra\n");
            printf("3- Depurar\n");
            printf("4- Listar\n");
            printf("0- Salir\n");

            scanf("%d",&opcion);

            switch(opcion)
            {
                case 1:
                    retorno = parserPersona(pArchivo, listaDestinatarios);
                    persona_printAll(listaDestinatarios);
                    system("pause");
                    system("cls");
                    break;
                case 2:
                    retorno = parserListaNegra(pArchivo, ListaListaNegra);
                    persona_printAll(ListaListaNegra);
                    system("pause");
                    system("cls");
                    break;
                case 3:
                    depurar(listaDestinatarios,ListaListaNegra, listaNueva);
                    persona_printAll(listaNueva);
                    system("pause");
                    system("cls");
                    break;
                case 4:
                    persona_ordenarPorNombre(listaDestinatarios);
                    system("pause");
                    system("cls");
                    break;

                case 0:
                    seguir = 'n';
                    break;
            }
        }

    }
    return 0;
}
