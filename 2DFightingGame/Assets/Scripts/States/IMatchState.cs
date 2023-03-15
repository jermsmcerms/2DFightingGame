namespace TDFG {
    public abstract class AMatchState
    {
        virtual public AMatchState ChangeState(MatchState newState) {
            return newState switch {
                MatchState.START => new MatchStartState(),
                MatchState.FIGHT => new MatchFightState(),
                MatchState.END => new MatchEndState(),
                _ => null,
            };
        }

        public abstract void Update(MatchManager matchManager);
    }

    public enum MatchState {
        START,
        FIGHT,
        END
    }
}
