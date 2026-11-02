namespace ClassLibraryProject
{
   public interface IMyLibrary
    {
        public int Add(int x,int y);
    }
    public class MyLibrary : IMyLibrary
    {
        public int Add(int x, int y)
        {
            return x + y;
        }
    }
}
