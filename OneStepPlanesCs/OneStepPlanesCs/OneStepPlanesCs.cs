using SldWorks;

namespace OneStepPlanesCs
{
    class Class1
    {
        [STAThread]
        static void Main(string[] args)
        {
            SldWorks.SldWorks swApp = new SldWorks.SldWorks();
            ModelDoc2 swModel = swApp.IActiveDoc2;
            SelectionMgr selMgr = swModel.SelectionManager;
            FeatureManager featureMgr = swModel.FeatureManager;

            bool ref_plane_is_selected = false;
            var seed_sketch_points = new List<ISketchPoint>();
            IFeature? seed_ref_plane = null;

            for (int i=1; i<=selMgr.GetSelectedObjectCount2(-1); i++)
            {
                Console.WriteLine(selMgr.GetSelectedObjectType3(i, -1));
                if (selMgr.GetSelectedObjectType3(i, -1) == 4) { //swSelDATUMPLANES
                    if (ref_plane_is_selected)
                    {
                        Console.WriteLine("Choose only one plane. Program aborted.");
                        System.Environment.Exit(1);
                    }

                    ref_plane_is_selected = true;
                    seed_ref_plane = selMgr.GetSelectedObject6(i, -1);
                }
                else if (selMgr.GetSelectedObjectType3(i, -1) == 25) { //swSelEXTSKETCHPOINTS
                    seed_sketch_points.Add(selMgr.GetSelectedObject6(i, -1));
                }
            }

            // Terminate program if necessary plane and points are not selected.
            if (!ref_plane_is_selected || seed_sketch_points.Count == 0)
            {
                Console.WriteLine("One plane and one or more points selection required for this function. Program aborted.");
                System.Environment.Exit(1);
            }
            
            // Insert reference plane(s)
            foreach(ISketchPoint p in seed_sketch_points)
            {
                seed_ref_plane?.Select2(false, 0);  // False: means re-select after selection clear
                p.Select2(true, 1);
                featureMgr.InsertRefPlane(1, 0, 4, 0, 0, 0);
            }

            swModel.ClearSelection2(true);

        }
    }
}