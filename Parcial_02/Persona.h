
#ifndef Persona_H_INCLUDED
#define Persona_H_INCLUDED

typedef struct {
    int id;
    char nombre[50];
    char email[100];

}Persona;
#endif


Persona* persona_new();

int persona_setId(Persona* this, int id);

int persona_setNombre(Persona* this,char* name);

int persona_setEmail(Persona* this,char* email);

int persona_getSId();
int persona_getId(Persona* this);

void* persona_getNombre(Persona* this);
void* persona_getEmail(Persona* this);


int persona_append (Persona* this, char* name, char* email);
void persona_print(ArrayList* this);
void persona_printAll(ArrayList* this);
void persona_ordenarPorNombre (ArrayList* this);
void depurar(ArrayList* listaDestinatarios, ArrayList* ListaNegra, ArrayList* nuevaLista);
