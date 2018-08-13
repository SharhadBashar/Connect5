using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Montrium.Connect.ClinicalDirectory.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class RoleProperty
    {
        public int[] ProcessZone { get; set; }
        public char[] Security { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Roles
    {
        /// <summary>
        /// 
        /// </summary>
        public static Dictionary<int, RoleProperty> rolesTable = new Dictionary<int, RoleProperty>()
        {
            //{Job Role number,  new RoleProperty{ ProcessZone = new int[] {Process Zones {1, 2, ..., 11}, Security = new char[] {Security for each process zone {R, W, L}}}}
            {1, new RoleProperty{ ProcessZone = new int[] {1,2,4}, Security = new char[] {'R', 'L', 'W' } } },
            {2, new RoleProperty{ ProcessZone = new int[] {2,3,5}, Security = new char[] {'R', 'R', 'R' } } },
            {3, new RoleProperty{ ProcessZone = new int[] {1,2,3,4}, Security = new char[] {'L', 'L', 'W', 'R' } } },
            {4, new RoleProperty{ ProcessZone = new int[] {1,2,3,4,5}, Security = new char[] {'L', 'W', 'R', 'R', 'R' } } },
            {5, new RoleProperty{ ProcessZone = new int[] {2,3,4}, Security = new char[] {'W', 'W', 'R' } } }
        };        
    }
}
