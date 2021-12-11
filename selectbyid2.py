# Precondition: SOLIDWORKS opened with a part file

import win32com.client
import pythoncom

swApp = win32com.client.Dispatch("SLDWORKS.Application")

swModel = swApp.ActiveDoc
modelExt = swModel.Extension

arg1 = win32com.client.VARIANT(pythoncom.VT_DISPATCH, None)
modelExt.SelectByID2("mysketch", "SKETCH", 0, 0, 0, False, 0, arg1 , 0)

