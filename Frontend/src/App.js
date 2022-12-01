import logo from './logo.svg';
import './App.css';
import axios from 'axios';
function testPost() {

  const article = {
	userName: "letatthinh",
	password: "T@eath1nh",
	displayName: "Trasonz",
	firstName: "Thinh",
	middleName: "Tat",
	lastName: "Le",
	birthday: "1997-02-15",
	email: "letatthinh.1997@gmail.com"
  };
    axios.post('https://localhost:7039/api/users', article)
        .then(response => console.log(response.data));
}

function App() {
	return (
		<div className="App">
			<header className="App-header">
				<img src={logo} className="App-logo" alt="logo" />
				<p>
					Edit <code>src/App.js</code> and save to reload.
				</p>
				<a
					className="App-link"
					href="https://reactjs.org"
					target="_blank"
					rel="noopener noreferrer"
				>
					Learn React
				</a>
				<button onClick={testPost}>Test this shit</button>
			</header>
		</div>
	);
}

export default App;

