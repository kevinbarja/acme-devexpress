﻿using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace Acme.Module.BusinessObjects.acme
{

    public partial class Service
    {
        public Service(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
