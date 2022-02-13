# OneStepPlanes python version

OneStepPlanes is a Solidworks Macro to duplicate planes at the selected point(s).

Written for a test project for Python Macro test.

![OneStepPlanesFunction](https://user-images.githubusercontent.com/11843820/153733915-7d841328-b681-45a6-8c25-f005befa7f83.png)

## Concept

![call chain](https://user-images.githubusercontent.com/11843820/153733734-83f1c6c6-15d0-488f-afe4-630e4451c023.png)

## Prerequisites

- Python win32com library
```bash
pip install pywin32
```

- python command exists in path environment. If not, activate your python environment in .bat file before python call.

## Configuration

1. Download: Copy this directory in your local strage or anywhare your Solidworks can address.
2. Modify file path in .swp into your path to .bat file downloaded.
```VBA
Call Shell("C:\.................\OneStepPlanes\one_step_planes.bat", vbNormalFocus)
```
3. Run the .swp file from your Solidworks.

## Usage

1. Select a plane, and one or more points.
2. Run the macro. The plane is dupulicated at the selected points.

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License
[MIT](https://choosealicense.com/licenses/mit/)