#!/bin/bash

# make sure GODOT_BIN is set
if [ -z "$GODOT_BIN" ]; then
    echo "Environment variable GODOT_BIN is unset! Set it to the Godot executable."
fi

# create/clear reports
if [ -d ./reports ]; then
    rm -rf ./reports/*
else 
    mkdir -p ./reports
fi

# create/clear screenshots
if [ -d ./screenshots ]; then
    rm -rf ./screenshots/*.png
else
    mkdir -p ./screenshots
    # .gdignore will prevent godot from importing these files
    touch ./screenshots/.gdignore
fi

# build sln
dotnet build

# run tests
"$GODOT_BIN" --path . -s -d res://addons/gdUnit4/bin/GdUnitCmdTool.gd -a res://test/

