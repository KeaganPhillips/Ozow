
# Run 
Follow the follwoing steps to run the application.
Ensure that you have docker installed.
*Please note:* This was developed and tested on an Ubuntu machine (Not Windows) with docker installed.

## Conway's Game Of Life
- Clone the Repo: `git clone git@github.com:KeaganPhillips/Ozow.git`
- CD into the rep: `cd Ozow/ConwaysGameOfLife`
- Build the docker image: `docker build -t ozow-conway .`
- Run the app: `docker run --rm ozow-conway:latest`
- Get it IP Address underwhich the container is running: `docker ps | grep ozow-conway | awk '{print $1}' | xargs docker inspect | grep IPAddress`
- In your browser, browse to the application with the IP, e.g. `http://172.17.0.2/`
- Play the game!

## Copy everything else and build
- Clone the Repo: `git clone git@github.com:KeaganPhillips/Ozow.git`
- CD into the rep: `cd Ozow/AnExerciseInSorting`
- Build the docker image: `docker build -t ozow-counting .`
- Run the app: `docker run --rm ozow-counting:latest "Contrary to popular belief, the pink unicorn flies east."`