#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "Arraylist.h"
#include "Usuario.h"
#include "Temas.h"
#include "Parser.h"
#include "Validaciones.h"
#include "Controller.h"

int main()
{
    ArrayList* listaUsuarios = al_newArrayList();
    ArrayList* listaTemas = al_newArrayList();
    char prueba[50] ;
    int retorno;
    //int dato;
    int opcion;
    FILE* pArchivo = NULL;
    FILE* pArchivo2 = NULL;
    char seguir='s';


    if(listaUsuarios != NULL )
    {
        while(seguir=='s')
        {
            printf("1-  LISTAR USUARIOS \n");
            printf("2-  LISTAR TEMAS \n");
            printf("3-  ESCUCHAR TEMA \n");
            printf("4-  GUARDARESTADISTICA \n");
            printf("2-  INFORMAR\n");
            printf("0- Salir\n");
            scanf("%d",&opcion);

            switch(opcion)
            {
                case 1:
                    parserUsuarios(pArchivo, listaUsuarios);
                    Usuario_ordenar(listaUsuarios);
                    Usuario_printAll(listaUsuarios);
                    system("pause");
                    system("cls");
                    break;
                case 2:
                    parserTemas(pArchivo2, listaTemas);
                    Temas_ordenar(listaTemas);
                    Temas_printAll(listaTemas);
                    system("pause");
                    system("cls");
                    break;
                case 3:
                    retorno = getValidEmail("email: ", "error\n", "error lenght\n", prueba, 50, 2);
                    if(retorno == 0)
                    {
                        printf("true\n");
                        system("pause");
                        retorno =  Usuario_buscarEmail(listaUsuarios, prueba);
                        if(retorno >0)
                        {

                            retorno =  Usuario_buscarPassword(listaUsuarios,retorno, "id mauris vulputate elementum");
                            //aca si  retorno es -1 decir que la contra no  existe
                            printf("%d", retorno);
                        }


                    }

                    //esTelefono("asda");
                    /*if(esEmail("as45@."))
                    {
                        printf("es\n");

                        }

                    else {
                        printf("no es\n");
                    }*/

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
