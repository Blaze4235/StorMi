import './App.css';

// Importing components
import {FormTextField} from './components/common/FormTextField';
import {ButtonCustom} from './components/common/ButtonCustom';
import {DropDown} from './components/common/DropDown';

function App() {
  return (
    <div className="App">
      <FormTextField inpId="forExample" inpW="100" labelText="Example of usage FormTextField:" labelPos="block"></FormTextField>
      <FormTextField inpId="forExample2" inpW="50" labelText="Example of usage FormTextField (inline):" labelPos="inline"></FormTextField>
      <div>
        <ButtonCustom text="PRIMARY" type="primary"></ButtonCustom>
        <ButtonCustom text="SECONDARY" type="secondary"></ButtonCustom>
      </div>
      <div>
        <DropDown></DropDown>
      </div>
      <div>
        <a href="#">This is a link</a>
      </div>
    </div>
  );
}

export default App;
