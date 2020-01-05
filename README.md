## **Flappy Bird by Jean-Pacôme Delmas**

Je m'excuse par avance du franglais.

Le code a été commenté dans la mesure du possible.

J'ai suivi quelsques tutos, fait beaucoup de recherches (sur des forums unity par exemples). Il y a peut-être des petits bouts de code venant d'internet mais pas de code provenant de jeux FlappyBird déjà existants, j'ai juste pris quelques idées.

### **Description de l'application:**

J'ai suivi le TP puis j'ai modifié des éléments qui sont plus conforme au jeu d'origine.
J'ai également ajouté un menu paramètre.

#### **Ce qui a été fait:**

Il y a 5 scènes: les 4 scenes du TP ainsi qu'une scene pour les paramètres accessible à partir de la toute première scene.

_**D'une manière générale:**_

- Une icone android.
- Un background lors du chargement de l'application.
- Un stokage du meilleur score avec PlayerPrefs.
- La gestion du retour android qui, soit quitte l'application, soit charge la scène initiale.

_**Dans la 1ere scène (Init):**_

- Un background qui scroll composé de 2 Quad (se trouve dans GameObject -> 3DObject).
J'ai suivi le tuto https://www.youtube.com/watch?v=epRPKFsOPck, j'ai modifié ma façon de faire le scoll du background car
avec la façon de faire du TP, les background se séparaient au fur et à mesure (même avec des prefabs).
    - Le premier quad gère le background (jour).
    - le second quad gère le floor. Ce quad est DontDestroyOnLoad et servira pour toutes les scènes, de plus le script
    FloorManager est un singleton pour être sur d'avoir 1 seule instance de ce quad.
- Un titre composé de 2 sprites (titre en lui même et un bird animé). Ces 2 sprites ont un mouvement vertical comme sur
le jeu d'origine.
- Un canvas composé des 2 boutons (play et parameter). Quand on clique sur le bouton play, la 2ème scène se lance et
quand on clique sur le bouton parameter, la scene des paramètre se lance.
- Un GameObject vide qui est DontDestroyOnLoad et qui gère les paramètres avec le scrip ParamManager, et il contient
(en children) 3 birds de couleur différentes qui sont caché à l'écran.
- Un GameObject vide qui est DontDestroyOnLoad et qui permet la gestion du retour android.

**_Dans la scene des paramètre (Param):_**

- Un background qui scroll composé d'un quad qui gère le background (nuit).
- Deux toggles groups avec leur titre chacun:
    - Le 1er pour choisir son skin de bird: green (default), blue ou purple.
    - Le 2eme pour choisir la difficulté du jeu: easy (1 paire de pipe à la fois et vitesse des pipes normale),
    normal (2 paire de pipe à la fois et vitesse des pipes normale) et hard (2 paire de pipe à la fois et vitesse des
    pipes doublée).
- Un bouton OK pour revenir à la 1ère scène (Init).

**_Dans la 2ème scene (Menu):_**

- Un background qui scroll, utilise les sprites de background (jour et nuit) de façon aléatoire, qui est DontDestroyOnLoad
pour les scènes qui suivent. Par contre, on le destroy et on recré un singleton à chaque fois qu'on load la scène 2.
- Deux sprites (get ready et tap tap)
- Un GameObject vide qui contient seulement le script GameState comme vu en TP. Ce script permet de gérer le score, savoir
si le bird est mort et si le jeu est en pause.
- Un second GameObject vide contenant un script pour gérer le bird, il va copier le bon bird (green, blue, purple) de
ParamManager de la scène 1.

**_Dans la 3ème scene (Game):_**

- Les 2 paires de pipes ainsi que les 2 box qui permettent d'augmenter le score.
- Un bouton pause/play qui permet de mettre sur pause et reprendre le jeu.

**_Dans la 4ème scene (GameOver):_**
C'est un scène qui se charge en mode Additive (par dessus la scène 3)

- Différents sprites qui reproduisent la scène de game over du vrai jeu. Avec un gestion des médailles si on fait des gros
scores et un affichage d'un petit sprite qui nous renseigne si on a fait un nouveau neilleur score.
- Deux boutons:
    - Un bouton play pour pouvoir rejouer (charge la scène 2)
    - Un bouton menu pour retourner sur la scène 1 (utile pour charger les paramètres).

#### Ce qui a pris du temps:

La réalisation du TP en général mais plus particulièrement:
- avoir un background qui ne se sépare pas au fil du temps (cad les sprites qui étaient bien cote à cote au debut laissaient
un espace de plus en plus grand au fil du temps), donc passer de l'utilisation de prefab au quad.
- comprendre qu'il fallait des toggles group dans la scene des paramètres au lieu de simples boutons pour pouvoir sélectionner
un bird et une difficulté en même temps.
- de comprendre comment fonctionne DontDestroyOnLoad et de modifier le jeu pour avoir que des singletons (cad 1 seul bird,
1 seul background, etc...).
- PLEIN de petits bugs et arrangement en tout genre.

### **Test sur Téléphone:**

- Honor View 20
- Samsung Galaxy A5 2016
