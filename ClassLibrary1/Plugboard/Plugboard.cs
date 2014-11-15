using System.Collections.Generic;

namespace EnigmaEmulator.Plugboard
{
    public class Steckerbrett
    {
        private Dictionary<char, char> _steckerbrett;

        public Steckerbrett()
        {
            _steckerbrett = new Dictionary<char, char>();
        }

        

        public void Stecker(char a, char b)
        {
            if ((_steckerbrett.ContainsKey(a) || _steckerbrett.ContainsKey(b)) && _steckerbrett[a] != b)
                throw new PlugboardChainingException();
            _steckerbrett[a] = b;
            _steckerbrett[b] = a;
        }

        public char Translate(char c)
        {
            if (_steckerbrett.ContainsKey(c))
                return _steckerbrett[c];
            return c;
        }
    }
}
