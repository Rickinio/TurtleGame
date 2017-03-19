# TurtleGame
### A game about a turtle searching for the exit.

The solution is composed by 3 projects:

    1. The console application
    2. A class library that all domain models live.
       They are in a seperate project cause now we can create a nuget package out of them.
    3. A Test project where we achieved almost 100% code coverage.


In order to run the project you will need to create two files, the **game-settings** file and the **moves** file.

game-settings file example:
```javascript
{  
   "BoardXSize":5,
   "BoardYSize":5,
   "Mines":[  
      {  
         "X":2,
         "Y":1
      },
      {  
         "X":2,
         "Y":2
      },
      {  
         "X":2,
         "Y":3
      }
   ],
   "Exit":{  
      "X":4,
      "Y":2
   },
   "TurtleInitialPosition":{  
      "X":0,
      "Y":1
   },
   "TurtleInitialHeading":"north"
}
```    

moves file example:
```jaavscript
[  
   [  
      "move",
      "rotate",
      "move",
      "move",
      "move",
      "rotate",
      "move",
      "move",
      "rotate",
      "rotate",
      "rotate",
      "move"
   ],
   [  
      "rotate",
      "rotate",
      "move",
      "move",
      "move",
      "rotate",
      "rotate",
      "rotate",
      "move",
      "move",
      "move",
      "move",
      "rotate",
      "rotate",
      "rotate",
      "move",
      "move"
   ],
   [  
      "rotate",      
      "move",
      "move",
      "move"
   ],
   [  
      "move",      
      "rotate",
      "move",
      "move",
      "move",
      "rotate",
      "move",
      "move",
      "move"
   ],
   [  
      "move",
      "move",
      "move",
      "move"      
   ]
]
```
