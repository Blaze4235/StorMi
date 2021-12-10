import './App.css';

// Importing components
import {FormTextField} from './components/common/FormTextField';
import {ButtonCustom} from './components/common/ButtonCustom';
import {DropDown} from './components/common/DropDown';
import { Routes, Route, Link } from 'react-router-dom';
import {SingIn} from './components/common/SingIn';
import {SingUp} from './components/common/SingUp';
import {UserCabinet} from './components/user/UserCabinet';
import {AdminCabinet} from './components/admin/AdminCabinet';

import { Navigate } from 'react-router-dom';

function App() {

  if(window.location.pathname === '/'){
    window.location.replace("/sign-in");
  }
  
  return (
    <div className="App">
      <Routes>
        <Route path="/sign-in" element={<SingIn/>}/>
        <Route path="/sign-up" element={<SingUp/>}/>
        <Route path="/cabinet" element={<UserCabinet/>}/>
        <Route path="/cabinetAdmin" element={<AdminCabinet/>}/>
      </Routes>
    </div>
  );
}
export default App;
