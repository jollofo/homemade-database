public interface CheeseDatabase{
    void Insert (CheeseModel cheese);
    void Delete (CheeseModel cheese);
    void Update (CheeseModel cheese);

    CheeseModel Find (Guid id);
    IEnumerable<CheeseModel> FindBy (string animalofOrigin, int age);

}