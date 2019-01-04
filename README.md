# Percorso_Circolare

Progetto finale Percorso Circolare.

## Setup dell'applicazione

Informazioni riguardo il funzionamento dell'applicazione.

### Database

Lo script per la creazione del database è presente sia nello ZIP inviato come allegato, sia in questa repository Git.
La stringa di connessione presente all'interno dell'applicazione, per connettere Entity Framework al database, cerca il database **PercorsoCircolare**, sorgente: **(LocalDb)\MSSQLLocalDB**.

### Solution

Per il debug dell'applicazione è necessario impostare il progetto **Circolare.WebAPI** e **Circolare.WEB** come **StartUp Projects** dalle proprietà della solution

### Librerie da NPM

Sono state utilizzate diverse librerie di terze parti, scaricate tramite NPM all'interno del progetto **Circolare.WEB**.

All'interno di questa repository non viene copiata la cartella **node_modules**, pertanto è necessario eseguire il comando:

```
npm install
```

**IMPORTANTE**

Tra le altre, sarà presente la libreria typings per Bootstrap, all'interno della cartella **node_modules > @types > bootstrap** e **node_modules > popper.js**. All'interno del file **index.d.ts** della prima, alla **riga 9**, è presente un import della seconda, che dopo il download da NPM sarà scritto:

```
import * as Popper from "popper.js"
```

In questo stato la build della solution fallisce perchè il modulo non viene trovato da Visual Studio, quindi è necessario cambiare la riga sopra in questo modo:

```
import * as Popper from "popper.js/dist/popper"
```

E' consigliabile riavviare Visual Studio dopo il download dei pacchetti NPM e della modifica di cui sopra.

## Info elementi terze parti

La solution è composta da quattro progetti:

- Circolare.DAL
- Circolare.BL
- Circolare.WebAPI
- Circolare.WEB

Per l'accesso ai dati è stato utilizzato Entity Framework, installato come pacchetto **NuGet** nel progetto **Circolare.DAL**.
La stringa di connessione è invece salvata sia nel file **App.config** del progetto **Circolare.DAL**, sia nel file **Web.config** del progetto **Circolare.WebAPI**.

Per la parte client è stato utilizzato Typescript, il cui compilatore è stato anch'esso installato come pacchetto **NuGet** nel progetto **Circolare.WEB**

Nel progetto **Circolare.WebAPI**, oltre ai pacchetti relativi alle API, è stato installato **StructureMap** per permettere la **dependency injection** nelle classi dei Controller (impostazioni nel file **DefaultRegistry.cs**) e il pacchetto per la gestione del **CORS**.
E' stata definita anche una classe (**CustomResolver.cs**) per ridefinire il resolver di default **JSON**.
