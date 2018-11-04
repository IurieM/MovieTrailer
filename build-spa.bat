@ECHO off

@ECHO Build Spa

cd src/Movie.Api

call npm install

call npm run build-prod

