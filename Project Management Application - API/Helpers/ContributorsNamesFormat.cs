namespace Project_Management_Application___API.Helpers
{
    public static class ContributorsNamesFormat
    {
        public static string GetString(this List<String> contributers , String ContributersString)
        {
            ContributersString = "";
            if(contributers.Count!=0)
            {
                foreach (var contributor in contributers)
                {
                    ContributersString += contributor + ",";
                }
                ContributersString = ContributersString.Remove(ContributersString.Length - 1);
            }
            return ContributersString; 
        }
    }
}
