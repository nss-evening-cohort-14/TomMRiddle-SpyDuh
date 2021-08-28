﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TomMRiddle_SpyDuh.Models;

namespace TomMRiddle_SpyDuh.DataAccessLayer
{
    public class SpyRepository
    {
        static List<Spy> _spies = new List<Spy>();

        // GetAll() return _spies field
        internal IEnumerable<Spy> GetAll()
        {
            var tempSpies = _spies;
            return tempSpies;
        }

        // Add newSpy Method
        internal void AddSpy(Spy newSpy)
        {
            newSpy.SpyID = Guid.NewGuid();

            _spies.Add(newSpy);
        }
        //internal void addSpyToFriendsList( Spy friendlySpy)
        //{

        //}

        // Get by ID Method
        internal Spy GetByID(Guid spyID)
        {
            var temp = _spies.FirstOrDefault(spy => spy.SpyID == spyID);
            return temp;

            //return _spies.FirstOrDefault(spy => spy.SpyID == spyID);
        }

        // Get by Skills
            internal IEnumerable<Spy> GetBySkill(string skill)
        {
            return _spies.Where(Spy => Spy.LSTSkills.Contains(skill));
        }

        // Get by Services
        //internal IEnumerable<Spy> GetByServices(List SpyServices services)
        //{
        //    return _spies.Where(spy => spy.SpyServices == services);
        //}

    internal IEnumerable<Spy> GetSpyFriends(Guid spyID)
    {
      return _spies.Where(x => _spies.FirstOrDefault(y => y.SpyID == spyID).LSTFriendlySpies.Contains(x.SpyID));
    }

    internal IEnumerable<Spy> GetSpyEnemies(Guid spyID)
    {
      return _spies.Where(x => _spies.FirstOrDefault(y => y.SpyID == spyID).LSTEnemySpies.Contains(x.SpyID));
    }


        // Get by Name Method
        internal IEnumerable<Spy> GetByName(string name)
        {
            return _spies.Where(Spy => Spy.Name.Contains(name));
        }

    internal SkillsAndServices GetSkillsAndServices(Guid spyID)
    {
      // Get the spy that is passed by controller
      var matchingSpy = _spies.FirstOrDefault(spy => spy.SpyID == spyID);

      // Create a local model to return the skills and services of that spy. 
      var SkillAndServiceModel = new SkillsAndServices
      {
        ListSkills = matchingSpy.LSTSkills,
        ListSpyServices = matchingSpy.SpyServices
      };

      return SkillAndServiceModel;
    }

        internal IEnumerable<Spy> GetSpiesBySkill(string skill)
        {
            return _spies.Where(Spy => Spy.LSTSkills.Contains(skill));
        }

        internal IEnumerable<string> GetSpyAvailableSkils(Guid spyID)
        {
            return _spies.FirstOrDefault(spy => spy.SpyID == spyID).LSTSkills;
        }


    }
}
