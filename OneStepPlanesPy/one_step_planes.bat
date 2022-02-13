@echo off
cd /d %~dp0
Python one_step_planes.py
IF %ERRORLEVEL%==1 pause