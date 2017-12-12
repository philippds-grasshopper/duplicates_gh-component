using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

using System.Linq;

namespace findDuplicates

{
    public class vanillaComponent : GH_Component
    {
        GH_Document GrasshopperDocument;
        IGH_Component Component;
        
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public vanillaComponent(): base("findDuplicates", "finding duplicates list of any type", "action description", "MyComponents", "Subcategory")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("list", "list", "list", GH_ParamAccess.list);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddIntegerParameter("dupCount", "dupCount", "dupCount", GH_ParamAccess.list);
            pManager.AddBooleanParameter("dupBool", "dupBool", "dupBool", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<string> list = new List<string>();
            DA.GetDataList(0, list);

            var dup = new findDuplicates_class(list);

            DA.SetDataList(0, dup.duplicates);
            DA.SetDataList(1, dup.boolDup);
        }


        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                // You can add image files to your project resources and access them like this:
                //return Resources.IconForThisComponent;
                return findDuplicates.Properties.Resources.dup;                
                //return null;                
            }
        }

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("DE08B92F-F676-4934-BE11-BFE4066E45E3"); }
        }
        
    }
}
