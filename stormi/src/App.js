import './App.css';

// Importing components
import {FormTextField} from './components/common/FormTextField';
import {ButtonCustom} from './components/common/ButtonCustom';
import {DropDown} from './components/common/DropDown';
import { Routes, Route, Link } from 'react-router-dom';
import {SingIn} from './components/common/SingIn';

function App() {
  return (
    <div className="App">
        <Routes>
          <Route path="/sing-in" element={<SingIn/>}/>
        </Routes>
    </div>
  );
}

export default App;
