namespace ProgramingPattern {
    //public interface ICommand {
    //    void Execute(GameActor actor);
    //}

    public interface ICommand {
        void Execute();
        void Undo();
    }
}
