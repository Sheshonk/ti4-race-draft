import logo from './logo.svg';
import './App.css';
import {
  BrowserRouter as Router,
  Routes,
  Route,
  Link
} from 'react-router-dom';
import Draft from './component/draft.js';
import Setup from './component/setup.js';

/*
player setup
  names
drafting
  draft claim (and fix)
  draft player order
  draft hand
  draft values in the pool
*/

function App() {
  return (
    <div>
      <Router>
        <Routes>
          <Route path="/" element={< Setup />}></Route>
          <Route path="/draft" element={< Draft />}></Route>
        </Routes>
      </Router>
    </div>
  );
}

export default App;
