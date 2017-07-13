//  “Id,nombre_tema,artista”.
typedef struct{
    int id;
    char name[50];
    char artista[50];
}Temas;

Temas* Temas_new(void);
int Temas_setId(Temas* this, int id);
int Temas_setName(Temas* this,char* name);
int Temas_setArtista(Temas* this,char* artista);
int Temas_getId(Temas* this);
void* Temas_getName(Temas* this);
void* Temas_getArtista(Temas* this);
void Temas_printAll(ArrayList* this);
void Temas_ordenar(ArrayList* this);
