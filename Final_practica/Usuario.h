
//“id,nombre,email,sexo,pais,password,ip_address”.

#ifndef Usuario_H_INCLUDED
#define Usuario_H_INCLUDED
 // Persona_H_INCLUDED
typedef struct{
    int id;
    char name[50];
    char email[50];
    char sexo[50];
    char pais[50];
    char password[50];
    char ip_adress[50];

}Usuario;
#endif
/** \brief Crea un usuario  nuevo y  reserva espacio en  memoria con el  tamaño de la estructura.
 * \param void
 * \return Usuario* Return (NULL) if Error [if can't allocate memory]
 *                  - (pointer to new Usuario) if ok
 */
Usuario* Usuario_new(void);

/** \brief  Sets an user  id
 * \param Usuario* this Pointer to Usuario
 * \param  int id of the user
 * \return int Return (-1) if Error [usuario  is  NULL pointer or id <0]
 *                  - ( 0) if Ok
 */
int Usuario_setId(Usuario* this, int id);
/** \brief  Sets an user  name
 * \param Usuario* this Pointer to Usuario
 * \param  char* name of the user
 * \return int Return (-1) if Error [usuario  is  NULL pointer or len name >0]
 *                  - ( 0) if Ok
 */
int Usuario_setName(Usuario* this,char* name);
/** \brief  Sets an user  email
 * \param Usuario* this Pointer to Usuario
 * \param  char* email of the user
 * \return int Return (-1) if Error [usuario  is  NULL pointer or len email >0]
 *                  - ( 0) if Ok
 */

int Usuario_setEmail(Usuario* this,char* email);
/** \brief  Sets an user  sexo
 * \param Usuario* this Pointer to Usuario
 * \param  char* sexo of the user
 * \return int Return (-1) if Error [usuario  is  NULL pointer or len sexo >0]
 *                  - ( 0) if Ok
 */

int Usuario_setSexo(Usuario* this,char* sexo);
/** \brief  Sets an user  pais
 * \param Usuario* this Pointer to Usuario
 * \param  char* pais of the user
 * \return int Return (-1) if Error [usuario  is  NULL pointer or len pais >0]
 *                  - ( 0) if Ok
 */

int Usuario_setPais(Usuario* this,char* pais);
/** \brief  Sets an user password
 * \param Usuario* this Pointer to Usuario
 * \param  char* password of the user
 * \return int Return (-1) if Error [usuario  is  NULL pointer or len password >0]
 *                  - ( 0) if Ok
 */

int Usuario_setPassword(Usuario* this,char* password);
/** \brief  Sets an user ip
 * \param Usuario* this Pointer to Usuario
 * \param  char* ip of the user
 * \return int Return (-1) if Error [usuario  is  NULL pointer or len ip >0]
 *                  - ( 0) if Ok
 */

int Usuario_setIP_adress(Usuario* this,char* ip);
/** \brief  Get an user ID
 * \param Usuario* this Pointer to Usuario
 * \return int Return (-1) if Error [usuario  is  NULL pointer]
 *                  - ( usuario->ID) if Ok
 */

int Usuario_getId(Usuario* this);
/** \brief  Get an user name
 * \param Usuario* this Pointer to Usuario
 * \return int Return NULL) if Error [usuario  is  NULL pointer]
 *                  - ( usuario->name) if Ok
 */

void* Usuario_getName(Usuario* this);

void* Usuario_getEmail(Usuario* this);

void* Usuario_getSexo(Usuario* this);

void* Usuario_getPais(Usuario* this);

void* Usuario_getPassword(Usuario* this);

void* Usuario_getIP_adress(Usuario* this);

void Usuario_printAll(ArrayList* this);

/** \brief  Compara two elements from any data type
 * \param Void* usuarioA Pointer to void
* \param Void* usuarioB Pointer to void
* \return int Return - ( 0) if usuarioA = usuarioB
*                    - ( 1) if usuarioA > usuarioB
*                    - ( -1) if usuarioA < usuarioB
 */
int Usuario_compareName(void* usuarioA,void* usuarioB);
int Usuario_comparePais(void* usuarioA,void* usuarioB);
int Usuario_compareEmail(void* usuarioA,void* usuarioB);

void Usuario_ordenar(ArrayList* this);

int Usuario_buscarEmail(ArrayList* this, char email[]);
int Usuario_buscarPassword(ArrayList* this, int id, char pass[]);

