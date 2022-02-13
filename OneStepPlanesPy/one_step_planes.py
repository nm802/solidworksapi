# Precondition: SOLIDWORKS opened. One seed refplane & one or more points selected.
# Postcondition: Insert Reference planes at selected points.

import sys
import win32com.client

swApp = win32com.client.Dispatch("SLDWORKS.Application")
swModel = swApp.ActiveDoc
selMgr = swModel.SelectionManager
featureMgr = swModel.FeatureManager

ref_plane_is_selected = False
seed_sketch_points = []
for i, dummy in enumerate(range(selMgr.GetSelectedObjectCount2(-1)),1):
    if selMgr.GetSelectedObjectType3(i, -1) == 4: #swSelDATUMPLANES
        if ref_plane_is_selected:
            print("Choose only one plane. Program aborted.")
            sys.exit(1)
        ref_plane_is_selected = True
        seed_ref_plane = selMgr.GetSelectedObject6(i, -1)
    elif selMgr.GetSelectedObjectType3(i, -1) == 25: #swSelEXTSKETCHPOINTS
        seed_sketch_points.append(selMgr.GetSelectedObject6(i, -1))

# Terminate program if necessary plane and points are not selected.
if not ref_plane_is_selected or len(seed_sketch_points) == 0:
    print("One plane and one or more points selection required for this function. Program aborted.")
    sys.exit(1)

# Insert reference plane(s)
for p in seed_sketch_points:
    seed_ref_plane.Select2(False, 0) # False: means re-select after selection clear
    p.Select2(True, 1)
    featureMgr.InsertRefPlane(1, 0, 4, 0, 0, 0)

swModel.ClearSelection2(True)