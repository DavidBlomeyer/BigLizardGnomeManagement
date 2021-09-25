using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleRepo
{
    public class PeopleContentRepo
    {
        private List<PeopleContent> _listOfPeople = new List<PeopleContent>();

        //C

        public void AddPersonToList(PeopleContent content)
        {
            _listOfPeople.Add(content);
        }

        //R

        public List<PeopleContent> GetPeopleList()
        {
            return _listOfPeople;
        }

        //U

        public bool UpdateExistingPeople(int originalIdNumber, PeopleContent newContent)
        {
            // Find the content
            PeopleContent oldContent = GetPeopleByIdNumber(originalIdNumber);

            // Update the content
            if (oldContent != null)
            {
                // EMPTY THING
                return true;
            }
            else
            {
                return false;
            }
        }

        //D

        public bool RemoveContentFromList(int idNumber)
        {
            PeopleContent content = GetPeopleByIdNumber(idNumber);

            if (content == null)
            {
                return false;
            }

            int intialCount = _listOfPeople.Count;
            _listOfPeople.Remove(content);

            if (intialCount > _listOfPeople.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Helper Methods
        public PeopleContent GetPeopleById(string id)
        {
            foreach (PeopleContent content in _listOfPeople)
            {
                if (content.ID.ToLower() == id.ToLower())
                {
                    return content;
                }
            }

            return null; // not found
        }

        public PeopleContent GetPeopleByIdNumber(int idNumber)
        {
            foreach (PeopleContent content in _listOfPeople)
            {
                if (content.IDNumber == idNumber)
                {
                    return content;
                }
            }

            return null; // not found
        }
    }
}

