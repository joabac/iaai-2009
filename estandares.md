# Estandares de Programacion a utilizar #

# Comentarios #

Utilizar Comentarios del tipo **XML**

_**Ejemplo**_

```

/// <summary>
        /// Valida caracteres validos para campo direccion
        /// </summary>
        /// <example>
        /// Urquiza 3225
        /// D'agostino 325 7º B
        /// Avda. San Martin 3452
        /// San juan 3225 (Pasillo) dto. 2º
        /// </example>
        /// <param name="cadena">Direccion a validar en formato String</param>
        /// <returns>
        /// true: si es valido  
        /// false: si no es valido 
        /// </returns>

```


# Nombres de Variables #

Para todas las variables que se generen utilizar nombres **autoexplicativos**

_**Ejemplo**_

**Prohibido**

`Alumno a = new Alumno();`

**Deberia ser**

`Alumno alumno = new Alumno();`


# Nombres de Metodos #

Para todos los metodos generados utilizar una sintaxis como se explica a continuacion


_**Priera letra en minuscula**_ + resto en minuscula + _separador_ + _**Siguente palabra comienza con mayuscula**_

separador = { `_` |NULL}

_**Ejemplo**_

```

public void altaAlumno()
{
     //codigo correctamente indentado
} 

```