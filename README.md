# Zoe
El projecte que farem és per fer vendes de regal, 
Hi ha dos entorns diferents depenen de l’usuari (els usuaris seran emmagatzemats a la taula ROL):
Si es admin tindrà accés a tots els productes per modificar, pujar nous, esborrar quantitat del stock o per afegir, veure les comandes rebudes, actualitzar l’inici, entre altres.

Si es un client només pot agafar productes, afegir extres i obligatòriament ha de fer un pagament.
 
El que hi serà a la part principal (inici) és alguns productes destacats o bé productes afegits recentment, es mostrarà a la part d'adalt les categories (en aquesta part farem servir la taula categories) 
Quan es fa click a una categoria es mostrarà tots els productes que estiguin dins de la categoria (farem servir la taula packs que està relacionada amb productes)

Quan el client té un producte seleccionat tindran l'opció d'afegir extras (dividides per categories, xocolata, xuxes, adorn, etc. quan trii la categoria podrà agafar el producte desitja (taula productes), quan afegeix un extra es mostra la suma total, pack + extra.

Hi ha un botó per afegir a la cistella i hi hauran dues opcions,
Si és usuari ha de iniciar sessió, es farà una cerca a la taula Usuaris per veure si existeix sinó ha de crear un.

Quan ja estigui en la seva sessió es demanaran les dades d'enviament i facturació, una vegada completa la informació es demanarà el mètode de pagament.

Al finalitzar la compra es mostrarà el num de venta i es generarà la factura automàticament  per l’usuari.

Hi haurà una taula proveïdors que emmagatzema tota la informació de cada un, té relació amb la taula productes.

En total tenim 7 taules per la base de dades:

· Usuaris
· Productes
· Packs
· Proveïdors
· Comanda
· Categoria
· Rol
