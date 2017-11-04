﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BankLocations.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Upwork_20171101_LocationValidationEntities : DbContext
    {
        public Upwork_20171101_LocationValidationEntities()
            : base("name=Upwork_20171101_LocationValidationEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int usp_InsertImages()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_InsertImages");
        }
    
        public virtual int usp_LoadTablesWithData()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_LoadTablesWithData");
        }
    
        public virtual int wsp_AssignVendorToBank(Nullable<int> vendorId, Nullable<int> siteId, string zone, string bank)
        {
            var vendorIdParameter = vendorId.HasValue ?
                new ObjectParameter("VendorId", vendorId) :
                new ObjectParameter("VendorId", typeof(int));
    
            var siteIdParameter = siteId.HasValue ?
                new ObjectParameter("SiteId", siteId) :
                new ObjectParameter("SiteId", typeof(int));
    
            var zoneParameter = zone != null ?
                new ObjectParameter("Zone", zone) :
                new ObjectParameter("Zone", typeof(string));
    
            var bankParameter = bank != null ?
                new ObjectParameter("Bank", bank) :
                new ObjectParameter("Bank", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("wsp_AssignVendorToBank", vendorIdParameter, siteIdParameter, zoneParameter, bankParameter);
        }
    
        public virtual int wsp_CadVendor_CRUD(string nextAction, Nullable<int> vendorId, ObjectParameter vendorId_OUTPUT, string vendorName, string vendorAbbreviation, string description)
        {
            var nextActionParameter = nextAction != null ?
                new ObjectParameter("NextAction", nextAction) :
                new ObjectParameter("NextAction", typeof(string));
    
            var vendorIdParameter = vendorId.HasValue ?
                new ObjectParameter("VendorId", vendorId) :
                new ObjectParameter("VendorId", typeof(int));
    
            var vendorNameParameter = vendorName != null ?
                new ObjectParameter("VendorName", vendorName) :
                new ObjectParameter("VendorName", typeof(string));
    
            var vendorAbbreviationParameter = vendorAbbreviation != null ?
                new ObjectParameter("VendorAbbreviation", vendorAbbreviation) :
                new ObjectParameter("VendorAbbreviation", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("wsp_CadVendor_CRUD", nextActionParameter, vendorIdParameter, vendorId_OUTPUT, vendorNameParameter, vendorAbbreviationParameter, descriptionParameter);
        }
    }
}