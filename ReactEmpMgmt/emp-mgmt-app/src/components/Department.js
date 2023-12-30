import React, { Component } from "react";
import { ButtonToolbar, Table } from "react-bootstrap";
import { Button, ButtonToolbarProps } from "react-bootstrap";

import { AddDeptModal } from "./AddDepartmentModal";

export class Department extends Component {
    constructor(props) {
        super(props);
        this.state = { deps: [], addModalDisplay: false }
    }

    componentDidMount() {
        this.refreshList();
    }

    refreshList() {
        fetch('https://localhost:44325/api/department')
            .then(response => response.json())
            .then(data => {
                console.log(data);
                this.setState({ deps: data });
            });
        console.log(this.deps);
        //this.setState();
        // this.setState({
        //     deps: [{ "DepartmentID": 1, "DepartmentName": "IT" }, { "DepartmentID": 2, "DepartmentName": "Support" }]
        // });
    }

    render() {
        const { deps } = this.state;
        let addModalClose = () => this.setState({ addModalDisplay: false });
        return (
            // <div className="mt-5 d-flex justify-content-left">
            //     <h3>This is Department Page.</h3>
            // </div>
            <div>
                <Table className="mt-4" striped bordered hover size="sm">
                    <thead>
                        <tr>
                            <th>Department ID</th>
                            <th>Department Name</th>
                        </tr>
                    </thead>
                    <tbody>
                        {deps.map(dep =>
                            <tr key={dep.ID}>
                                <td>{dep.ID}</td>
                                <td>{dep.Name}</td>
                            </tr>
                        )}
                    </tbody>
                </Table>
                <ButtonToolbar>
                    <Button
                        variant="primary" onClick={() => this.setState({ addModalDisplay: true })}>
                        Add Department
                    </Button>
                    <AddDeptModal show={this.state.addModalDisplay} onHide={addModalClose}></AddDeptModal>
                </ButtonToolbar>
            </div>

        )
    }
}