﻿using System.Collections.Generic;
using Dapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Npgsql;
using VolunteeringSystem.Models;

namespace VolunteeringSystem.DAO
{
    public class AgeGroupDao
    {
        public IEnumerable<AgeGroup> GetAll()
        {
            using (var sql = new NpgsqlConnection(ConnectionProvider.GetConnectionString()))
            {
                var list = sql.Query<AgeGroup>("SELECT * FROM age_group").AsList();
                return list;
            }
        }

        public AgeGroup Get(int ageGroupId)
        {
            using (var sql = new NpgsqlConnection(ConnectionProvider.GetConnectionString()))
            {
                return sql.QueryFirst<AgeGroup>("SELECT * FROM age_group WHERE id = @id", new {id = ageGroupId});
            }
        }

        public List<SelectListItem> ToSelectList(IEnumerable<AgeGroup> ageGroups)
        {
            var selectList = new List<SelectListItem>();
            foreach (var item in ageGroups)
                selectList.Add(new SelectListItem {Text = item.label, Value = item.id.ToString()});
            return selectList;
        }
    }
}