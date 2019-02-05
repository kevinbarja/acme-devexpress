using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace Acme.Module.BusinessObjects.acme
{

    public partial class Department
    {
        public Department(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
