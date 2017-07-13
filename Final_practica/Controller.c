#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "Arraylist.h"
#include "Usuario.h"
#include "Temas.h"
#include "Parser.h"
#include "Validaciones.h"


int controller_getDataUsuarios(Usuario* this, ArrayList* listaUsuarios, Temas* temas )
{
    int retorno;

    char email [50];
    char pass[50];
    retorno = getValidEmail("\nIngrese el  email de usuario: ","\nNo es un email valido\n","\nLongitud maxima 50", email,50,3);
    if(retorno == 0)
    {
        retorno = Usuario_buscarEmail(listaUsuarios, email);
        if(retorno >0)
        {
            retorno = getValidString("Ingresar contraseña: ", "\nNo es una contraseña valida\n","\nLongitud maxima 50", pass,50,3);
            if(retorno  == 0)
            {
                retorno = Usuario_buscarPassword(listaUsuarios,retorno, pass);
                if(retorno >0)
                {
                    //seleccionar cancion
                }
            }


        }

    }

    return retorno;
}
