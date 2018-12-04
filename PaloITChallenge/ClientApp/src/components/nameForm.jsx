import React, { Component } from 'react';
import Input from './common/input';
import axios from 'axios';

axios.interceptors.response.use(null, error => {
    const expectedError = error.response && error.response.status >= 400 && error.response.status < 500;
    if (!expectedError)
        alert("An unexpected error has occurred");

    return Promise.reject(error);
    
});

export class NameForm extends Component{
    displayName = NameForm.name
    state = {
        fullname: { firstname: "", lastname: "" },
        errors: {},
        result: {}
    };

    handleChange = ({ currentTarget: input }) => {
        const fullname = { ...this.state.fullname };
        fullname[input.name] = input.value.trim();
        this.setState({ fullname });
    }
    validate = () => {
        const errors = {};

        const { fullname } = this.state;
        
        if (fullname.firstname.trim() === '') 
            errors.firstname = 'First Name can not be empty.';
                      
        if (fullname.lastname.trim() === '')
            errors.lastname = 'Last Name can not be empty.';

        return Object.keys(errors).length === 0 ? null : errors;
    }
    handleSubmit = e => {
        e.preventDefault();

        const errors = this.validate();
        this.setState({ errors: errors || {} });
        if (errors) return;

        axios.post("api/NameForm", this.state.fullname).then((response) => {
            const result = response.data;
            console.log(result);
            this.setState({ result });
        });
        
    }  
    render() {
        const { fullname, errors, result } = this.state;
        return (
            <div className="container">
                <img src="http://palo-it.com/wp-content/uploads/2017/06/logo_website.png" />
                <h1>Palo IT Software Engineering Challenge</h1>
                <h3>Input Full Name</h3>
                <form onSubmit={this.handleSubmit}>
                    <Input name="firstname" value={fullname.firstname} label="First Name" onChange={this.handleChange} error={errors.firstname} />
                    <Input name="lastname" value={fullname.lastname} label="Last Name" onChange={this.handleChange} error={errors.lastname} />
                    <button className="btn btn-primary">Insert & Calculate</button>
                </form>
                {result.numOfConsecutive0s && <div className="alert alert-info">Name: {fullname.firstname} {fullname.lastname} </div>}
                {result.numOfConsecutive0s && <div className="alert alert-info">The largest number of consecutive 0s is {result.numOfConsecutive0s} </div>}
                {result.errorMesg && <div className="alert alert-danger">There are errors when saving the name {result.errorMesg} </div>}
                <p className="mt-5 mt-3 text-muted text-center">&copy; Merry Christmas </p>
            </div>
            );
    }

}

export default NameForm;